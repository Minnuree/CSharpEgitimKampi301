using CSharpEgitimKampi301.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEgitimKampi301.DataAccessLayer.Abstract
{
    public interface IProductDal : IGenericDal<Product>
    {
        List<Object> GetProductsSwithCategory(); // List olarak bir metot yazıyorum içine Product çünkü onu getireceğiz
        // Kategorileriyle beraber ürünleri getiren bir metot
        //DataAccess katmanında bu metodu çağırarak işlem yapacağız
    }
}
