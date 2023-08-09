using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Shopping.Entity.Base;

namespace Shopping.DAL.Abstract.DataManagement//interfaceleri abstract ta oluştururuz.
{//veri tabanı işlemleri.//repository hangi sınıfı veriyorsan database işlemlerini takip eden yapıdır.
    public interface IRepository<T> where T:AuditableEntity//add update get get all delete bu işlemleri burada gerçekleştireceğiz
    {                              //T dediğiğimiz generic yani her türlü tiptir.User dersek methodlar user için çalışacak.
                                   // iki tane referans ekleme işlemi vardır. ADD referance diyebiliriz yada alt enter yapabiliriz.
                                   //işlemci ne kadar güçlüyse trade/işlem oluştururuz. işlemler asenkron mantığıyla çalışır.
                                   //Asenkron işlem gönderince senkron gibi işlemin sonucunu beklemez ve işi verir geri döner yeni iş götürünce oradan
                                   //işi biten cevabı alır geri döner.//task asenkron çalışması için
        Task<T> GetAsync(Expression<Func<T, bool>> Filter, params string[] IncludeProperties);//linQ c# ın olayıdır.
        Task<IEnumerable<T>> GetALLAsync(Expression<Func<T, bool>> Filter=null, params string[] IncludeProperties);    
        Task<EntityEntry<T>>AddAsync(T Entity);//change tracking o an hangi işlem yapılacak.

        Task UpdateAsync(T Entity);
        Task RemoveAsync(T Entity);

    }
}
