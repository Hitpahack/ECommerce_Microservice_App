using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Product.API.Data;
using Product.API.DTO;
using Product.API.Entities;
using Product.API.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Product.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private ResponseDto _reponse;

        public CategoryController(ICategoryService categoryService, ResponseDto reponse)
        {
            _categoryService = categoryService;
            _reponse = reponse;
        }

        // GET: api/<CategoryController>
        [HttpGet]
        public async Task<IEnumerable<object>> Get()
        {
            try
            {
                IEnumerable<CategoryDto> categoryDto = await _categoryService.GetAllCategory();
                _reponse.Result = categoryDto;
            }
            catch (Exception ex)
            {
                _reponse.IsSuccess = false;
                _reponse.Errors = new List<string> { ex.Message };
            }
            return (IEnumerable<object>)_reponse;
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public async Task<object> Get(int id)
        {
            try
            {
                CategoryDto category = await _categoryService.GetCategoryId(id);
                _reponse.Result = category;
            }
            catch (Exception ex)
            {
                _reponse.IsSuccess = false;
                _reponse.Errors = new List<string> { ex.Message };
            }
            return _reponse;
        }

        // POST api/<CategoryController>
        [HttpPost]
        public async Task<object> Post([FromBody] CategoryDto category)
        {
            try
            {
                CategoryDto cat = await _categoryService.CreateUpdateCategoryAsync(category);
                _reponse.Result = cat;
            }
            catch (Exception ex)
            {
                _reponse.IsSuccess = false;
                _reponse.Errors = new List<string> { ex.Message };
            }
            return _reponse;

        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public async Task<object> Put(CategoryDto category)
        {
            try
            {
                CategoryDto cat = await _categoryService.CreateUpdateCategoryAsync(category);
                _reponse.Result = cat;
            }
            catch (Exception ex)
            {
                _reponse.IsSuccess = false;
                _reponse.Errors = new List<string> { ex.Message };
            }
            return _reponse;
        } 

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public async Task<object> Delete(int id)
        {
            try
            {
                bool isSuccess = await _categoryService.DeleteCategoryAsync(id);
                _reponse.Result = isSuccess;
            }
            catch (Exception ex)
            {
                _reponse.IsSuccess = false;
                _reponse.Errors = new List<string> { ex.Message };
            }
            return _reponse;
        }
    }
}
