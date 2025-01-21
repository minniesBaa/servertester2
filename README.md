# servertester2
servertester2 is a simple service written in Visual Basic that helps show the status of a server. It is useful if you want to know when your server goes down. It runs the test and then terminates, so it will need to be triggered at intervals.
# Use
We used Task Scheduler and set up two tasks. One runs every 5 minutes and shows a notification only if the server is down. The other one only runs when a user logs in, and shows a notification even if it's up.
## Our Configurations
1. ServerChecker-OnLogon:
	- Run only when user is logged on
	- Trigger:
		- Begin the task: `On workstation unlock`
		- Any user
	- Actions:
		- Action: Start a program
		- Program/Script: "path.../servertester2.exe"
		- Arguments: `-showOn`
	- Conditions:
		- Wake the computer to run this task
	- Settings:
		- Allow task to be run on demand
		- Run task as soon as possible after a scheduled start is missed

2. ServerChecker-Every10Min:
	- Run only when user is logged on
	- Trigger:
		- Begin the task: On a schedule
		- One time
		- Start: (any time before now)
		- Repeat task every: 10 minutes
		- For a duration of: Indefinitely
	- Actions:
		- Action: Start a program
		- Program/Script: "path.../servertester2.exe"
	- Conditions:
		- Wake the computer to run this task
	- Settings:
		- Allow task to be run on demand
# Custom Configurations
If supplied the `-showOn` flag, the application will respond with a toast notification showing if the server is on. If not, it will only display a notification if the server is down. You can use this to setup Task Scheduler tasks on your own schedule.
