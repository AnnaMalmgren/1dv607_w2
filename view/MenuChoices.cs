namespace view
{
    public enum MainMenu
    {
        Exit,

        AddMember,

        CompactList,

        VerboseList
    }

    public enum MemberMenuNoBoats
    {
        GoBack,
        ChangeMember,

        DeleteMember,

        RegisterBoat

    }

    public enum MemberMenu
    {
        GoBack,

        ChangeMember,

        DeleteMember,

        RegisterBoat,

      
        ChangeBoat,

        DeleteBoat
    }

    public enum ChangeMember
    {
        ChangeName = 1,
        ChangePersonalNr
    }

    public enum ChangeBoat
    {
        ChangeType = 1,
        ChangeLength
    }
}