using System.Collections.Generic;
using laba1;

namespace DataAccessLayer
{
    /// <summary>
    /// Универсальный репозиторий для работы с доменными сущностями.
    /// Определяет контракт CRUD-операций: создание, чтение, обновление, удаление.
    /// Конкретная реализация может быть через Dapper (ручной SQL) или EF Core (автоматический ORM).
    /// </summary>
    /// <typeparam name="T">
    /// Тип доменной сущности. Должен реализовывать <see cref="IDomainObject"/>,
    /// чтобы у сущности гарантированно было свойство Id.
    /// </typeparam>
    public interface IRepository<T> where T : IDomainObject
    {
        /// <summary>
        /// Добавляет новую сущность в источник данных.
        /// После выполнения метода свойство <c>Id</c> сущности должно быть заполнено
        /// значением, сгенерированным базой данных.
        /// </summary>
        /// <param name="obj">Сущность для добавления.</param>
        void Add(T obj);
        /// <summary>
        /// Возвращает все сущности из источника данных.
        /// </summary>
        /// <returns>Коллекция всех сущностей типа <typeparamref name="T"/>.</returns>
        IEnumerable<T> ReadAll();
        /// <summary>
        /// Возвращает одну сущность по её идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор сущности.</param>
        /// <returns>
        /// Найденная сущность или <c>null</c>, если сущность с таким Id не найдена.
        /// </returns>
        T ReadById(int id);
        /// <summary>
        /// Обновляет существующую сущность в источнике данных.
        /// Сущность ищется по значению свойства <c>Id</c>.
        /// </summary>
        /// <param name="obj">Сущность с обновлёнными данными.</param>
        void Update(T obj);
        /// <summary>
        /// Удаляет сущность из источника данных по её идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор удаляемой сущности.</param>
        void Delete(int id);
    }
}