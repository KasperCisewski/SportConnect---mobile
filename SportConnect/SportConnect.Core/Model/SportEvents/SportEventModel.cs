using System;

namespace SportConnect.Core.Model.SportEvents
{
    public class SportEventModel
    {
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
        public string SportTypeName { get; set; }
        public string AddressDescription { get; set; }
        public string QuantityOfEventParticipantsDescription { get; set; }
        public string ProposedEventSkillLevel { get; set; }
        public string SportEventManagerName { get; set; }
        public bool CanJoinToEvent { get; set; }
    }
}
