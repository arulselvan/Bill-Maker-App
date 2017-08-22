namespace WebApi.Repository
{
    using System;
    using System.Collections.Generic;
    using WebApi.Entity;
    public interface IProductRepository
    {
        IEnumerable<ProductViewModel> Get();
        ProductViewModel Get(Guid id);
        void Post(ProductViewModel viewModel);
        void Put(Guid id, ProductViewModel viewModel);
        void Delete(Guid id);
    }
}
