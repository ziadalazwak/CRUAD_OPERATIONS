using L_1_dependcy_injection.Data;
using L_1_dependcy_injection.Filters;
using Microsoft.AspNetCore.Mvc;

namespace L_1_dependcy_injection.Controllers
{
    [ApiController]
    [Route("[controller]")]
    
    public class ProductsController:ControllerBase
    {
        ApplicationDbcontext _dbcontext { get; set; }
        public ProductsController(ApplicationDbcontext dbcontext)
        {
            _dbcontext=dbcontext;
        }
        [HttpPost]
        [Route("")]
        public ActionResult<int>CreateProduct(Products product)
        {
            product.Id = 0;
            _dbcontext.Set<Products>().Add(product);_dbcontext.SaveChanges();
            return Ok(product.Id);
        }
        [HttpPut]
        [Route("")]
        public ActionResult UpdateProduct(Products product)
        {
            var exist = _dbcontext.Set<Products>().Find(product.Id);
            exist.Name = product.Name;
            exist.Sku = product.Sku;
            _dbcontext.Set<Products>().Update(exist); _dbcontext.SaveChanges();
            return Ok(exist);
        }
        [HttpGet]
        [Route("")]
        public ActionResult<IEnumerable<Products>> GetProduct() {
        var records= _dbcontext.Set<Products>().ToList();
            return Ok(records);
        
        }
        [HttpGet]
        [Route("{id}")]
        [LogsensAction]
        public ActionResult<Products> GetProductsById(int id) {
        var record= _dbcontext.Set<Products>().Find(id);
            return record!=null?NotFound():Ok(record); 
        }


        [HttpDelete]
        [Route("{id}")]
        public ActionResult DeleteProduct(int id) { 
        var exist= _dbcontext.Set<Products>().Find(id);
            _dbcontext.Set<Products>().Remove(exist);
            _dbcontext.SaveChanges();
            return Ok(exist);
                
                }

    }
}
