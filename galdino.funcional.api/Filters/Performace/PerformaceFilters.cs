using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace galdino.funcional.api.Filters.Performace
{
    public class PerformaceFilters : IAsyncActionFilter
	{
        public async Task OnActionExecutionAsync(
        ActionExecutingContext context,
        ActionExecutionDelegate next)
        {
            var stop = new Stopwatch();

            stop.Start();

            var resultContext = await next();

            stop.Stop();

            if (resultContext.Result is ObjectResult view)
            {
                var item = view.Value;

                if (item.GetType().GetProperty("TempoDeProcessamento") != null)
                    item.GetType().GetProperty("TempoDeProcessamento").SetValue(item, Convert.ToInt32(stop.Elapsed.TotalMilliseconds));
                view.Value = item;
            }
        }
    }
}
