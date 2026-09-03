namespace SpacyID.Domain.Models.Clients;

/// <summary>
/// Сторонний клиент
/// </summary>
public class Client
{

    /// <summary>
    /// Разрешенные доступы
    /// </summary>
    private static List<Scope> _scopes { get; set; } = [];

    /// <summary>
    /// Идентификатор
    /// </summary>
    public string ClientId { get; set; } = string.Empty;
    
    /// <summary>
    /// Секрет
    /// </summary>
    public string? ClientSecret {  get; set; } = null;

    /// <summary>
    /// Тип 
    /// </summary>
    public string ClientType { get; set; } = string.Empty;

    /// <summary>
    /// Разрешеные типы грантов (токен, рефреш токен и т.п.)
    /// </summary>
    public GrantType[] AllowedGrantTypes { get; set; } = [];

    /// <summary>
    /// Разрешенные доступы (Коды)
    /// </summary>
    public string[] AllowedScopes { get; set; } = _scopes.Select(s => s.Code).ToArray();

  
    /// <summary>
    /// Ссылки доступные для редиректа
    /// </summary>
    public string[] RedirectUrls { get; set; } = [];


    /// <summary>
    /// Добавление разрешения клиенту
    /// </summary>
    /// <param name="scope">Сущность разрешения</param>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="ArgumentException"></exception>
    public void AddScope(Scope scope)
    {
        if (scope is null)
        {
            throw new ArgumentNullException(nameof(scope));
        }

        if (_scopes.Contains(scope))
        {
            throw new ArgumentException($"Клиент уже содержит доступ {scope.Code}");
        }
    }

    /// <summary>
    /// Удаление разрешения у клиента
    /// </summary>
    /// <param name="scopeCode">Код разрешения</param>
    /// <exception cref="ArgumentNullException"></exception>
    public void RemoveScope(string scopeCode)
    {
        if (string.IsNullOrEmpty(scopeCode))
        {
            throw new ArgumentNullException(nameof(scopeCode));
        }

        var removeScope = _scopes.FirstOrDefault(s => s.Code == scopeCode);

        _scopes.Remove(removeScope);
    }

}
