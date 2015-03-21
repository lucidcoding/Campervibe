﻿using System;

namespace Campervibe.Domain.Constants
{
    public static class MaintenanceConstants
    {
        public static readonly decimal MileageBetweenChecks = 10000;
        public static readonly TimeSpan DurationBetweenChecks = new TimeSpan(365, 0, 0, 0);
    }
}
