using isk.Database.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Diagnostics.Tracing.StackSources;

namespace isk.GeneralAPI.Controllers
{
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        protected IRepository Repository;
        //protected IMapper mapper { get; set; }

        public BaseController(IRepository repository)
        {
            Repository = repository;
        }
    }
}