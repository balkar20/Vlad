// //Author Maxim Kuzmin//makc//

/** Данные. Объекты. Сущность "Product". */
export interface AppDataObjectProduct {

    /**
     * Идентификатор.
     * @type {number}
     */
    id: number;
  
    /**
     * Имя.
     * @type {string}
     */
    name: string;

    /**
     * Описание.
     * @type {string}
     */
    description: string;
  
    /**
     * Цена.
     * @type {number}
     */
    price: number;

    /**
     * Идентификатор объекта, где хранятся данные сущности "DummyOneToMany".
     * @type {number}
     */
    objectProductCategoryId: number;

  }
  
  /** Данные. Объекты. Сущность "Product". Создать. */
  export function appDataObjectProductCreate(): AppDataObjectProduct {
    return {} as AppDataObjectProduct;
  }
  