# EventLogMonitor

This is a simple .NET 4.8.1 application that can be used to hook event logs and display any changes in a table. Events logged during the monitoring period can be exported to CSV or XML.

## Installation

You can clone this repository then build it your self or download the binary from the release tab.

## Screenshots

![GUI](https://raw.githubusercontent.com/AndrewRathbun/EventLogMonitor/master/imgs/GUI.jpg)

![GUIpopulated](https://raw.githubusercontent.com/AndrewRathbun/EventLogMonitor/master/imgs/GUIpopulated.jpg)

![EventDetails](https://raw.githubusercontent.com/AndrewRathbun/EventLogMonitor/master/imgs/EventDetails.jpg)

![HookedLogs](https://raw.githubusercontent.com/AndrewRathbun/EventLogMonitor/master/imgs/HookedLogs.jpg)

![Help](https://raw.githubusercontent.com/AndrewRathbun/EventLogMonitor/master/imgs/Help.jpg)

# ChangeLog

### 2.3
* Added indicator for running as Administrator
* Renamed column headers in GUI
* Added more Event Log Channels to monitor
* Updated nuget packages

### 2.2
* Forked/updated version
* Signed binary
* Updated nuget packages
* Added Export to CSV
* Added file sizes to Display Hooked Logs

### v2.1
* Fix a bug where the details column is displyed in the event id column.
* Added Tooltip on the log details cells

### v2.0
* Added Start / Stop log monitoring feature
* Bug fixes and general improvements

### v1.0
* Initial Version
