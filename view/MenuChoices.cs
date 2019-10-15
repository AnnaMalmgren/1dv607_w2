namespace view
{
    public enum MainMenu
    {
        None = -1,

        Exit,

        AddMember,

        CompactList,

        VerboseList
    }

    public enum MemberMenu
    {
        None = -1,

        GoBack,

        ChangeMember,

        DeleteMember,

        RegisterBoat,
      
        ChangeBoat,

        DeleteBoat
    }

    public enum ChangeMember
    {
        None = -1,
        GoBack,
        ChangeName,
        ChangePersonalNr 
    }

    public enum ChangeBoat
    {
        None = -1,
        GoBack,
        ChangeType,
        ChangeLength
    }
}