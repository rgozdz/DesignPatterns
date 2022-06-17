using System.Collections.Generic;

namespace DesignPatterns.Behavioral
{
    public class Participant
    {
        public int Value { get; set; }
        private readonly Mediator _mediator;

        public Participant(Mediator mediator)
        {
            _mediator = mediator;
            _mediator.AddParticipant(this);
        }

        public void Say(int value)
        {
           _mediator.Broadcast(this, value);
        }

        public void Receive(int value)
        {
            Value += value;
        }
    }

    public class Mediator
    {
        private List<Participant> participants = new List<Participant>();

        public void Broadcast(Participant source, int value)
        {
            foreach (var p in participants)
                if (p != source)
                    p.Receive(value);
        }

        public void AddParticipant(Participant participant)
        {
            participants.Add(participant);
        }
    }
}
