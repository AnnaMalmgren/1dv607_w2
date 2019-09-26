namespace view
{
    public enum MainMenu
    {
        Exit,

        AddMember,
        CompactList,

        VerboseList
    }

    public enum MemberMenu
    {
        Exit,
        ChangeMember,

        DeleteMember,

        RegisterBoat,

        ChangeBoat,

        DeleteBoat
    }

    public enum ChangeMember
    {
        Exit,
        ChangeName,
        ChangePersonalNr
    }

    public enum ChangeBoat
    {
        Exit,
        ChangeType,
        ChangeLength
    }

}