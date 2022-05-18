using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Newtonsoft.Json;
using System.Drawing.Imaging;
using MessagingToolkit.QRCode;
using MessagingToolkit.QRCode.Codec.Data;

namespace Proyecto_final
{
    public class GenerateQR
    {
        private GenerateQR() { }
        private static GenerateQR _instance;
        public static GenerateQR GetInstance()
        {
            if (_instance == null)
            {
                _instance = new GenerateQR();
            }
            return _instance;
        }


        public void crearQRpng(Store store, string path)
        {
            List<Store> stores = new List<Store> { store };
            string json = Createjson(stores);
            var encoder = new MessagingToolkit.QRCode.Codec.QRCodeEncoder();
            encoder.QRCodeScale = 5;
            Bitmap encoded = encoder.Encode(json);
            encoded.Save(path, ImageFormat.Png);
        }

        public Store LeerQRpng(string path)
        {
            Image img;
            using (var bmpTemp = new Bitmap(path))
            {
                img = new Bitmap(bmpTemp);
            }
            var decoder = new MessagingToolkit.QRCode.Codec.QRCodeDecoder();
            string data = decoder.Decode(new QRCodeBitmapImage(img as Bitmap));
            return readJson(data)[0];
        }
        string Createjson(List<Store> store)
        {
            return JsonConvert.SerializeObject(store);
        }
        List<Store> readJson(string json)
        {
            return JsonConvert.DeserializeObject<List<Store>>(json);
        }

    }

    public class Product
    {
        public int idProduct { get; set; }
        public string name { get; set; }
        public int quantity { get; set; }
        public float price { get; set; }

    }
    public class Store
    {
        public string idStore { get; set; }
        public string storeName { get; set; }
        public List<Product> products { get; set; }
    }
}