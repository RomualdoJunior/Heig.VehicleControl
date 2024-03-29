﻿using Heig.VehicleControl.Domain.Common;

namespace Heig.VehicleControl.Domain.Entities
{
    public class Answer : BaseEntity, IAggregateRoot
    {
        public Answer(string title)
        {
            Title = title;
        }

        public string Title { get; private set; }
        public string? AdditionalObservation { get; private set; }
        public bool Ok { get; private set; }

        public virtual Checklist Checklist { get; set; }
    }
}