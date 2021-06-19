using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using qrweb.businesslogic.Repositories;
using qrweb.models;
using System.Threading.Tasks;
using qrweb.businesslogic;
using qrweb.businesslogic.Entities;
using qrweb.businesslogic.User;
using qrweb.Extensions;

namespace qrweb.Controllers
{
    public class UserController : Controller
    {
        private readonly IUser _userAggregate;
        private readonly IReadOnlyUserRepository _userRepository;
        private readonly IQrCodeGenerator _qrCodeGenerator;

        public UserController(
            IUser userAggregate,
            IReadOnlyUserRepository userRepository,
            IQrCodeGenerator qrCodeGenerator)
        {
            _userAggregate = userAggregate;
            _userRepository = userRepository;
            _qrCodeGenerator = qrCodeGenerator;
        }
        public async Task<IActionResult> Index()
        {
            var userEntities = await _userRepository.GetAll();
            if(userEntities ==null) 
                return View(new List<UserListItemViewModel>());

            var users = userEntities.ToListItems();
            
            return View(users);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var userEntity = await _userRepository.Get(id);
            if (userEntity == null)
                return NotFound();

            return View(userEntity.ToDetails());
        }

        [HttpGet]
        public IActionResult Create()
        {
            var viewModel = new CreateUserViewModel();
            viewModel.Id = Guid.NewGuid();
            viewModel.QrCode = _qrCodeGenerator.Generate(viewModel.Id);
            viewModel.B64QrCodeString = Convert.ToBase64String(viewModel.QrCode);

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserViewModel model)
        {
            var userEntity = new UserEntity
            {
                Id = model.Id,
                Name = model.Name,
                B64QrCodeString = model.B64QrCodeString
            };
            await _userAggregate.Create(userEntity);

            return RedirectToAction(nameof(Details), new {id = userEntity.Id});
        }
    }
}
