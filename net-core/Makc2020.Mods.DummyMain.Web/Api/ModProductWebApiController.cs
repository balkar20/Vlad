//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Execution;
using Makc2020.Core.Base.Ext;
using Makc2020.Mods.Product.Base.Common.Jobs.Option.List.Get;
using Makc2020.Mods.Product.Base.Jobs.Item.Get;
using Makc2020.Mods.Product.Base.Jobs.List.Get;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Makc2020.Mods.Product.Web.Api
{
    /// <summary>
    /// Мод "Product". Веб. API. Контроллер.
    /// </summary>
    [ApiController, Route("api/dummy-main")]
    public class ModProductWebApiController : ControllerBase
    {
        #region Properties

        private ModProductWebApiModel MyModel { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="model">Модель.</param>
        public ModProductWebApiController(ModProductWebApiModel model)
        {
            MyModel = model;
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Получить список.
        /// </summary>
        /// <param name="input">Ввод.</param>
        /// <returns>Результат выполнения с данными списка.</returns>
        [Route("list"), HttpGet]
        public async Task<IActionResult> Get([FromQuery] ModProductBaseJobListGetInput input)
        {
            var result = new ModProductBaseJobListGetResult();

            var (execute, onSuccess, onError) = MyModel.BuildActionListGet(input);

            try
            {
                result.Data = await execute().CoreBaseExtTaskWithCurrentCulture(false);

                onSuccess(result);
            }
            catch (Exception ex)
            {
                onError(ex, result);
            }

            return Ok(result);
        }

        /// <summary>
        /// Получить элемент.
        /// </summary>
        /// <param name="intput">Ввод.</param>
        /// <returns>Результат выполнения с данными элемента.</returns>
        [Route("item"), HttpGet]
        public async Task<IActionResult> Get([FromQuery] ModProductBaseJobItemGetInput input)
        {
            var result = new ModProductBaseJobItemGetResult();

            var (execute, onSuccess, onError) = MyModel.BuildActionItemGet(input);

            try
            {
                result.Data = await execute().CoreBaseExtTaskWithCurrentCulture(false);

                onSuccess(result);
            }
            catch (Exception ex)
            {
                onError(ex, result);
            }

            return Ok(result);
        }

        /// <summary>
        /// Получить варианты выбора сущности "DummyManyToMany".
        /// </summary>
        /// <returns>Результат выполнения с вариантами выбора.</returns>
        [Route("options/dummy-many-to-many"), HttpGet]
        public async Task<IActionResult> GetOptionsDummyManyToMany()
        {
            var result = new ModProductBaseCommonJobOptionListGetResult();

            var (execute, onSuccess, onError) = MyModel.BuildActionOptionDummyManyToManyListGet();

            try
            {
                result.Data = await execute().CoreBaseExtTaskWithCurrentCulture(false);

                onSuccess(result);
            }
            catch (Exception ex)
            {
                onError(ex, result);
            }

            return Ok(result);
        }

        /// <summary>
        /// Получить варианты выбора сущности "DummyOneToMany".
        /// </summary>
        /// <returns>Результат выполнения с вариантами выбора.</returns>
        [Route("options/dummy-one-to-many"), HttpGet]
        public async Task<IActionResult> GetOptionsDummyOneToMany()
        {
            var result = new ModProductBaseCommonJobOptionListGetResult();

            var (execute, onSuccess, onError) = MyModel.BuildActionOptionDummyOneToManyListGet();

            try
            {
                result.Data = await execute().CoreBaseExtTaskWithCurrentCulture(false);

                onSuccess(result);
            }
            catch (Exception ex)
            {
                onError(ex, result);
            }

            return Ok(result);
        }

        /// <summary>
        /// Добавить элемент.
        /// </summary>
        /// <param name="intput">Ввод.</param>
        /// <returns>Результат выполнения с данными элемента.</returns>
        [Route("item"), HttpPost]
        public async Task<IActionResult> Post([FromBody] ModProductBaseJobItemGetOutput input)
        {
            var result = new ModProductBaseJobItemGetResult();

            var (execute, onSuccess, onError) = MyModel.BuildActionItemInsert(input);

            try
            {
                result.Data = await execute().CoreBaseExtTaskWithCurrentCulture(false);

                onSuccess(result);
            }
            catch (Exception ex)
            {
                onError(ex, result);
            }

            return Ok(result);
        }

        /// <summary>
        /// Обновить элемент.
        /// </summary>
        /// <param name="intput">Ввод.</param>
        /// <returns>Результат выполнения с данными элемента.</returns>
        [Route("item"), HttpPut]
        public async Task<IActionResult> Put([FromBody] ModProductBaseJobItemGetOutput input)
        {
            var result = new ModProductBaseJobItemGetResult();

            var (execute, onSuccess, onError) = MyModel.BuildActionItemUpdate(input);

            try
            {
                result.Data = await execute().CoreBaseExtTaskWithCurrentCulture(false);

                onSuccess(result);
            }
            catch (Exception ex)
            {
                onError(ex, result);
            }

            return Ok(result);
        }

        /// <summary>
        /// Удалить элемент.
        /// </summary>
        /// <param name="intputData">Ввод.</param>
        /// <returns>Результат выполнения.</returns>
        [Route("item"), HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] ModProductBaseJobItemGetInput input)
        {
            var result = new CoreBaseExecutionResult();

            var (execute, onSuccess, onError) = MyModel.BuildActionItemDelete(input);

            try
            {
                await execute().CoreBaseExtTaskWithCurrentCulture(false);

                onSuccess(result);
            }
            catch (Exception ex)
            {
                onError(ex, result);
            }

            return Ok(result);
        }

        #endregion Public methods
    }
}