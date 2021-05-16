using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Wolf.Infrastructure.Core.Configurations.Response;
using Wolf.ManagerService.Domain.Repository;
using Wolf.Systems.Data.Abstractions;

namespace Wolf.ManagerService.Controllers
{
    /// <summary>
    /// 基础控制器
    /// </summary>
    public class BaseController : Controller
    {
        #region 格式化响应信息

        /// <summary>
        ///
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <param name="data"></param>
        /// <param name="success"></param>
        /// <param name="failed"></param>
        /// <returns></returns>
        protected async Task<JsonResult> CommitUofAndFormatMsg(CancellationToken cancellationToken,
            Func<object> data = null,
            Action success = null,
            Func<string> failed = null)
        {
            var res = await HttpContext.RequestServices.GetService<IUnitOfWork<ManagerDbContext>>()
                .SaveChangesAsync(cancellationToken);
            return FormatMsg(res >= 0, data?.Invoke(), success, failed);
        }

        /// <summary>
        /// 成功响应
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="message">提示信息</param>
        /// <returns></returns>
        protected JsonResult Success<T>(T data, string message = "success")
        {
            var result = new ApiResultResponse<object>(200, data, message);
            return base.Json(result);
        }

        /// <summary>
        /// 错误响应
        /// </summary>
        /// <param name="message"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        protected JsonResult Error(string message, int? code = null)
        {
            var result = new ApiResultResponse<object>(code ?? 201, null, message);
            return base.Json(result);
        }

        /// <summary>
        /// 错误响应
        /// </summary>
        /// <param name="message">错误提示</param>
        /// <param name="data">扩展信息</param>
        /// <param name="code">状态码</param>
        /// <returns></returns>
        protected JsonResult Error<T>(string message, T data, int? code = null)
        {
            var result = new ApiResultResponse<object>(code ?? 201, data, message);
            return base.Json(result);
        }

        #region 格式化消息

        /// <summary>
        /// 格式化消息
        /// </summary>
        /// <param name="res"></param>
        /// <param name="data"></param>
        /// <param name="success"></param>
        /// <param name="failed"></param>
        /// <returns></returns>
        private JsonResult FormatMsg(bool res, object data = null, Action success = null,
            Func<string> failed = null)
        {
            if (res)
            {
                success?.Invoke();
                return Success(data);
            }

            return Error(failed?.Invoke() ?? "异常", data);
        }

        #endregion

        #endregion
    }
}
