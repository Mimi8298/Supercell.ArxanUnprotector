namespace Gee.External.Capstone;

/// <summary>
///     Register.
/// </summary>
/// <typeparam name="TId">
///     The type of the register's unique identifier.
/// </typeparam>
public abstract class Register<TId> where TId : Enum
{
    /// <summary>
    ///     Register's Name.
    /// </summary>
    private readonly string _name;

    /// <summary>
    ///     Create a Register.
    /// </summary>
    /// <param name="id">
    ///     The register's unique identifier.
    /// </param>
    /// <param name="name">
    ///     The register's name.
    /// </param>
    private protected Register(TId id, string name)
    {
        Id = id;
        _name = name;
    }

    /// <summary>
    ///     Get Register's Unique Identifier.
    /// </summary>
    public TId Id { get; }

    /// <summary>
    ///     Determine if Diet Mode is Enabled.
    /// </summary>
    /// <remarks>
    ///     Indicates if Diet Mode is enabled. A boolean true indicates it is enabled. A boolean false otherwise.
    /// </remarks>
    public bool IsDietModeEnabled => CapstoneDisassembler.IsDietModeEnabled;

    /// <summary>
    ///     Get Register's Name.
    /// </summary>
    /// <remarks>
    ///     Represents the register's name if, and only if, Diet Mode is disabled. To determine if Diet Mode is
    ///     disabled, call <see cref="IsDietModeEnabled" />.
    /// </remarks>
    /// <exception cref="System.NotSupportedException">
    ///     Thrown if Diet Mode is enabled.
    /// </exception>
    public string Name
    {
        get
        {
            CapstoneDisassembler.ThrowIfDietModeIsEnabled();
            return _name;
        }
    }

    /// <summary>
    ///     Determine if This Object is Equal to Another Object.
    /// </summary>
    /// <param name="object">
    ///     An object to compare to. Should not be a null reference.
    /// </param>
    /// <returns>
    ///     A boolean true if this object is equal to the object. A boolean false otherwise.
    /// </returns>
    public override bool Equals(object @object)
    {
        bool isEqual = @object != null;
        if (isEqual)
        {
            Register<TId> register = @object as Register<TId>;
            isEqual = register != null;
            if (isEqual)
            {
                isEqual = Id.Equals(register.Id);
                isEqual = isEqual && _name == register._name;
            }
        }

        return isEqual;
    }

    /// <summary>
    ///     Get Object's Hash Code.
    /// </summary>
    /// <returns>
    ///     The object's hash code.
    /// </returns>
    public override int GetHashCode()
    {
        int hashCode = 13;
        hashCode = hashCode * 7 + Id.GetHashCode();
        hashCode = _name != null ? hashCode * 7 + _name.GetHashCode() : 0;

        return hashCode;
    }
}