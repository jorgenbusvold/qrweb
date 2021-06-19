using System;
using System.IO;
using QRCoder;

namespace qrweb.businesslogic
{
    public interface IQrCodeGenerator
    {
        byte[] Generate(Guid id);
    }

    public class QrCodePictureProvider : IQrCodeGenerator
    {
        private readonly Uri _baseUrl;

        public QrCodePictureProvider(Uri baseUrl)
        {
            _baseUrl = new Uri(baseUrl,"User/Details/");
        }

        public byte[] Generate(Guid id)
        {
            var generator = new QRCodeGenerator();
            var payloadUrl = new PayloadGenerator.Url($"{_baseUrl}{id}");
            var qrCodeData = generator.CreateQrCode(payloadUrl,QRCodeGenerator.ECCLevel.Q);
            var qrCode = new QRCode(qrCodeData);
            var bitmatImage = qrCode.GetGraphic(20);

            using (MemoryStream stream = new MemoryStream())
            {
                bitmatImage.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return stream.ToArray();
            }
        }
    }
}
