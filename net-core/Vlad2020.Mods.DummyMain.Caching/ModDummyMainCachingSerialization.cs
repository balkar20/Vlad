﻿//Author Vlad Balkarov//vlad//

using Vlad2020.Mods.DummyMain.Base.Common.Jobs.Option.Item.Get;
using Vlad2020.Mods.DummyMain.Base.Common.Jobs.Option.List.Get;
using Vlad2020.Mods.DummyMain.Base.Jobs.Item.Get;
using Vlad2020.Mods.DummyMain.Base.Jobs.List.Get;

namespace Vlad2020.Mods.DummyMain.Caching
{
    /// <summary>
    /// Мод "DummyMain". Кэширование. Сериализация кэшируемых моделей.
    /// </summary>
    public static class ModDummyMainCachingSerialization
    {
        #region Public methods

        /// <summary>
        /// Инициализировать.
        /// </summary>
        public static void Init()
        {
            var model = ProtoBuf.Meta.RuntimeTypeModel.Default;

            InitCommonJobOptionItemGetOutput(model);
            InitCommonJobOptionListGetOutput(model);

            InitJobItemGetOutput(model);
            InitJobListGetOutput(model);
        }

        #endregion Public methods

        #region Private methods

        private static void InitJobItemGetOutput(ProtoBuf.Meta.RuntimeTypeModel model)
        {
            ModDummyMainBaseJobItemGetOutput obj;

            model.Add(typeof(ModDummyMainBaseJobItemGetOutput), false).Add(
                nameof(obj.ObjectDummyMain),
                nameof(obj.ObjectsDummyManyToMany),
                nameof(obj.ObjectsDummyMainDummyManyToMany),
                nameof(obj.ObjectDummyOneToMany)
                );
        }

        private static void InitJobListGetOutput(ProtoBuf.Meta.RuntimeTypeModel model)
        {
            ModDummyMainBaseJobListGetOutput obj;

            model.Add(typeof(ModDummyMainBaseJobListGetOutput), false).Add(
                nameof(obj.Items),
                nameof(obj.TotalCount)
                );
        }

        private static void InitCommonJobOptionItemGetOutput(ProtoBuf.Meta.RuntimeTypeModel model)
        {
            ModDummyMainBaseCommonJobOptionItemGetOutput  obj;

            model.Add(typeof(ModDummyMainBaseCommonJobOptionItemGetOutput ), false).Add(
                nameof(obj.Name),
                nameof(obj.Value)
                );
        }

        private static void InitCommonJobOptionListGetOutput(ProtoBuf.Meta.RuntimeTypeModel model)
        {
            ModDummyMainBaseCommonJobOptionListGetOutput obj;

            model.Add(typeof(ModDummyMainBaseCommonJobOptionListGetOutput), false).Add(
                nameof(obj.Items)
                );
        }

        #endregion Private methods
    }
}