# BDM4065ControlApp
#### Control Philips BDM4065 monitor via its RS232 interface
 Heavily based on the code from https://github.com/andy-w/BDM4065ControlApp


#### Features of my version
Global Keyboard Hooks (full list below) to allow commands to be sent from any active window
Runs in background when launched
Set com port by adding argument to launch, e.g "BDMControlApp.exe COM1"

#### Keybinds
Keys.Add //Volume Up

Keys.Subtract //Volume Down

Keys.NumPad0 //Power Toggle

Keys.NumPad1 //VGA

Keys.NumPad2 //DP

Keys.NumPad3 //MiniDP

Keys.NumPad4 //HDMI

Keys.NumPad5 //HDM

So the reason why i added global keybinds is actually a bit of a special use case. i have a MCE (RC6) Remote Sensor which with a program called "AdvancedMCERemoteMapper" i can map keyboard presses to buttons on the MCE Remote.

So with my Logitech Harmony universal remote i can map on screen buttons such as "DP" to "Green" on the MCE Remote and then map "Green" on the MCE Remote to Numpad2
