using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.DAL.Abstract.DataManagement
{
    public interface IUnitOfWork:IAsyncDisposable//garbage collector boş işe yaramayan codları atar,kendisini dispose etsin.
    {
        IUserRepository UserRepository { get;}//varolanı getleyecek yani diğer repositorylerden
                                              //haberdar olacak ama manipulasyon yapamaz.
        IProductRepository ProductRepository { get; }
        IOrderRepository OrderRepository { get; }
        IOrderDetailRepository OrderDetailRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        Task<int> SaveChangeAsync();//tüm gelen repositoryleri alır db işlemini yaptı
                                    //tüm repositoryleri bilmesi lazım.
                                    //trans action mantığı ile çalışır.
        //otellerin alanları farklı bir otel tc tutarken diğeri evlilik cüzdanı istiyor ama aynı
        //sitede tek bir standarda sahip değil. Farklı farklı istekleri var. propertiesleri ona göre oluşturmak lazım.
        //run time da oluştururuz. her bir firma için classlarını oluştururuz run time da 
        //reflection canlıda newletme setleme nedir?
        //Factory design pattern? creaitonal pattenr?

    }
}
