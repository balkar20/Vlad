# Библиотека классов Makc2020.Core.Caching

Библиотека классов, предназначенная для реализации связанной с кэшированием функциональности ядра.

## Настройка

1. Открыть файл **Makc2020.Core.Caching/ConfigFiles/Core.Caching.config.json**.

2. В разделе **ConnectTimeout** указать таймаут подключения к базе данных Redis:
**целое число**.

3. В разделе **DbIndex** указать индекс базы данных Redis:
**целое число**.

4. В разделе **ExpiryInSeconds** указать промежуток времени в секундах, по истечении которого записи в
кэше становятся недействительными: **целое число**.

5. В разделе **Host** указать адрес хоста базы данных Redis:
**строка**.

6. В разделе **Hosts** указать адреса хостов базы данных Redis:
**массив строк**.

7. В разделе **IsCachingEnabled** указать признак того, что кэш включен:
**логическое значение**.

8. В разделе **IsGlobalStorageEnabled** указать признак того, что включено глобальное хранилище для
кэша в виде базы данных Redis: **логическое значение**.

9. В разделе **KeyPrefix** указать префикс ключа для хранения кэша в базе данных Redis:
**строка**.

10. В разделе **Password** указать пароль для подключения к базе данных Redis:
**строка**.

11. В разделе **Port** указать порт базы данных Redis:
**целое число**.

**Пример:**

    {
      "ConnectTimeout": 5000,
      "DbIndex": 0,
      "ExpiryInSeconds": 3600,
      "Host": "localhost",
      "Hosts": null,
      "IsCachingEnabled": true,
      "IsGlobalStorageEnabled": false,
      "KeyPrefix": "Makc2020",
      "Password": null,
      "Port": 6379
    }