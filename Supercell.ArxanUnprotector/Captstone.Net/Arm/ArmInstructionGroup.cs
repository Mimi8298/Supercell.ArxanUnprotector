namespace Gee.External.Capstone.Arm;

/// <summary>
///     ARM Instruction Group.
/// </summary>
public sealed class ArmInstructionGroup : InstructionGroup<ArmInstructionGroupId>
{
    /// <summary>
    ///     Create an ARM Instruction Group.
    /// </summary>
    internal ArmInstructionGroup(ArmInstructionGroupId id, string name) : base(id, name)
    {
    }

    /// <summary>
    ///     Create an ARM Instruction Group.
    /// </summary>
    /// <param name="disassembler">
    ///     A disassembler.
    /// </param>
    /// <param name="id">
    ///     The instruction group's unique identifier.
    /// </param>
    /// <returns>
    ///     An ARM instruction group.
    /// </returns>
    internal static ArmInstructionGroup Create(CapstoneDisassembler disassembler, ArmInstructionGroupId id)
    {
        if (!Cache.Groups.TryGetValue(id, out ArmInstructionGroup @object))
        {
            string name = NativeCapstone.GetInstructionGroupName(disassembler.Handle, (int) id);
            @object = new ArmInstructionGroup(id, name);
            Cache.Groups.Add(id, @object);
        }
     
        return @object;
    }
    
    private static class Cache
    {
        [ThreadStatic] private static Dictionary<ArmInstructionGroupId, ArmInstructionGroup> _groups;

        public static Dictionary<ArmInstructionGroupId, ArmInstructionGroup> Groups
        {
            get
            {
                return _groups ??= new Dictionary<ArmInstructionGroupId, ArmInstructionGroup>();
            }
        }
    }
}