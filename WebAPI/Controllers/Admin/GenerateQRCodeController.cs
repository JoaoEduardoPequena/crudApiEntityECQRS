using Microsoft.AspNetCore.Mvc;
using Net.Codecrete.QrCodeGenerator;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using WebAPI.QrCodeExtension;

namespace WebAPI.Controllers.Admin
{
    [Tags("Geral")]
    [Route("api/geral/GenerateQRCode")]
    [ApiExplorerSettings(GroupName = "geral")]
    public class GenerateQRCodeController : ControllerBase
    {

        [HttpGet]
        public IActionResult GenerateQRCode()
        {
            // URL da página de boas-vindas
            string url = "https://www.google.com";
            // Gerar o QR Code
            var qrCode = QrCode.EncodeText(url, QrCode.Ecc.Medium);
            var bitmap = QrCodeExtensions.ToBitmap(qrCode,10, 4);
            // Converter o bitmap em um array de bytes
            using var ms = new MemoryStream();
            bitmap.Save(ms, ImageFormat.Png);
            byte[] byteImage = ms.ToArray();

            // Retornar o QR Code gerado como uma imagem PNG
            return File(byteImage, "image/png");
        }

        //[HttpGet("welcome")]
        //public IActionResult Welcome()
        //{
        //    return Content("Bem-vindo à página de boas-vindas!");
        //}



    }
}








