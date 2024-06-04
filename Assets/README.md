# MGS.DramaPlayer
# Summary

Drama Player base on FSM to play sequence plots.

# Demand
- Player to manage and control plot.
- Extend custom Plot.
- Config plots in json file.

# Environment
- .net framework 4.6 or above.
- Unity 2021 or above.

# Config
- Config plots in a json file, like DramaMeta.json.

# Extend
- Create a class for plot and inherit from the Plot<T>.
- Create a class or struct for parameter of plot.

# Usage
1. Create a Instance of DramaPlayer.
1.  Read config file (json content).
1.  Deserialize json content to DramaMeta.
1.   Init DramaPlayer.

---

Copyright © 2024 Mogoson.	mogoson@outlook.com