﻿//Author Vlad Balkarov//vlad//

using Vlad2020.Core.Base.Execution;
using Vlad2020.Core.Base.Ext;
using Vlad2020.Mods.DummyMain.Base.Common.Jobs.Option.List.Get;
using Vlad2020.Mods.DummyMain.Base.Jobs.Item.Get;
using Vlad2020.Mods.DummyMain.Base.Jobs.List.Get;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Vlad2020.Mods.DummyMain.Web.Api
{
    /// <summary>
    /// Мод "DummyMain". Веб. API. Контроллер.
    /// </summary>
    [ApiController, Route("api/dummy-main")]
    public class ModDummyMainWebApiController : ControllerBase
    {
        #region Properties

        private ModDummyMainWebApiModel MyModel { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="model">Модель.</param>
        public ModDummyMainWebApiController(ModDummyMainWebApiModel model)
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
        public async Task<IActionResult> Get([FromQuery] ModDummyMainBaseJobListGetInput input)
        {
            var result = new ModDummyMainBaseJobListGetResult();

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
        public async Task<IActionResult> Get([FromQuery] ModDummyMainBaseJobItemGetInput input)
        {
            var result = new ModDummyMainBaseJobItemGetResult();

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
            var result = new ModDummyMainBaseCommonJobOptionListGetResult();

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
            var result = new ModDummyMainBaseCommonJobOptionListGetResult();

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
        public async Task<IActionResult> Post([FromBody] ModDummyMainBaseJobItemGetOutput input)
        {
            var result = new ModDummyMainBaseJobItemGetResult();

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
        public async Task<IActionResult> Put([FromBody] ModDummyMainBaseJobItemGetOutput input)
        {
            var result = new ModDummyMainBaseJobItemGetResult();

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
        public async Task<IActionResult> Delete([FromQuery] ModDummyMainBaseJobItemGetInput input)
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