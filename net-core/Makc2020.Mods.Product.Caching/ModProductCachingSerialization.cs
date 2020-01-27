//Author Maxim Kuzmin//makc//

using Makc2020.Mods.Product.Base.Common.Jobs.Option.Item.Get;
using Makc2020.Mods.Product.Base.Common.Jobs.Option.List.Get;
using Makc2020.Mods.Product.Base.Jobs.Item.Get;
using Makc2020.Mods.Product.Base.Jobs.List.Get;

namespace Makc2020.Mods.Product.Caching
{
    /// <summary>
    /// Мод "Product". Кэширование. Сериализация кэшируемых моделей.
    /// </summary>
    public static class ModProductCachingSerialization
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
            ModProductBaseJobItemGetOutput obj;

            model.Add(typeof(ModProductBaseJobItemGetOutput), false).Add(
                nameof(obj.ObjectProduct),
                nameof(obj.ObjectsProductFeature),
                nameof(obj.ObjectsProductProductFeature),
                nameof(obj.ObjectProductCategory)
                );
        }

        private static void InitJobListGetOutput(ProtoBuf.Meta.RuntimeTypeModel model)
        {
            ModProductBaseJobListGetOutput obj;

            model.Add(typeof(ModProductBaseJobListGetOutput), false).Add(
                nameof(obj.Items),
                nameof(obj.TotalCount)
                );
        }

        private static void InitCommonJobOptionItemGetOutput(ProtoBuf.Meta.RuntimeTypeModel model)
        {
            ModProductBaseCommonJobOptionItemGetOutput  obj;

            model.Add(typeof(ModProductBaseCommonJobOptionItemGetOutput ), false).Add(
                nameof(obj.Name),
                nameof(obj.Value)
                );
        }

        private static void InitCommonJobOptionListGetOutput(ProtoBuf.Meta.RuntimeTypeModel model)
        {
            ModProductBaseCommonJobOptionListGetOutput obj;

            model.Add(typeof(ModProductBaseCommonJobOptionListGetOutput), false).Add(
                nameof(obj.Items)
                );
        }

        #endregion Private methods
    }
}