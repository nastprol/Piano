﻿using Domain.Infrastructure;

namespace Domain
{
    public interface IMapChange
    {
        PianoKey[] GetNextKeyLine(int numberInWidth, Note note);
    }
}