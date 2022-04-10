VC Screen Integration for the TDS GTN 750Xi/650Xi

This mod provides a non-interactive integration of the TDS GTN 750Xi or 650Xi screen into the cockpit.

It consists of to parts, first an MSFS addon that can replace any screen gauge in the VC, and second an App that captures the screen of the TDS GTNXi and feeds them to the addon.

There is no interactivity on the screen in the cockpit (meaning it is showing what the GTNXi screen shows, but you can not control it via the VC), this is intended as a visual reference and for immersion. You still need to control the GTNXi via its window, e.g. on a second screen or tablet.

With tuned settings I only have a small performance impact, not more than using any other complex glass gauge screen.

### Installation
* Unzip the download
* Copy the content from the "Community" folder into the MSFS "Community" directory-
	- The addon "gtn-screen-relay" is mandatory
	- Included are also reference integration addons for some aircraft, and you only need to copy those that you want:
		- Just Flight PA28 Arrow (GTN 750Xi)
		- Just Flight PA28 Turbo Arrow (GTN 750Xi)
		- Carenado M20R Ovation (GTN 750Xi)
		- Carenado PA44 Seminole (GTN 750Xi)
		- Cessna C172 (stock steam gauge) (GTN 650Xi)
		- Robin  CAP-10 (stock) (GTN 650Xi)
	- See further down in the "Aircraft Integration" section for instructions on how to create integration mods for other aircraft.
* Run GTNXiScreenRelay.exe from the "App" folder
* The TDS GTN 750Xi or 650Xi window needs to be open and not minimized, but it does not have to be in the foreground. You can check if the relay is working by going to http://localhost:45783/GTN750 or http://localhost:45783/GTN650 in your browser. You should see a snapshot of the units screen (might not work on the first request, simply reload).
* For the Just Flight and Carenado aircraft you have to have them configured for GTN750 usage via their VC tablets.

### App Settings
The app can be configured through various settings to optimize performance and quality.  
All settings are applied "live", so you can easily tune them and also adapt them on the fly , e.g. increase the refresh rate when you have FPS to spare enroute and reduce it during takeoff.

* Image Format:  
	"JPEG High" is recommended.  
	While "PNG" has the best quality, it is larger and slower to process, resulting in a lower refresh rate.
* Refresh Interval:  
	The interval in milliseconds between requests of a new frame. A lower value means a higher refresh rate.  
	Setting this to 0 will limit the refresh rate only by the processing time and the sim frames.
* Scaling:  
	The native resolution of the TDS GTNXi window is a main factor to performance. If you are displaying the GTNXi window on a high resolution device, like a 4K monitor or a high-res tablet, it can help sim performance to scale the image down. But as this introduces further processing on the app side, resulting in a reduced refresh rate.  
	Due to that you will likely not see an improvement when you set it in the range of ~70-99%. Keep it rather at 100%.  
	See the "Performance Tips" section below for better alternatives on high-res screens.
* GTN750/GTN650 Bezel/Hide Frame options:  
	Those options reflect the equally named settings from the "TDS GTNXi Flight Sim" application. You have to set them to the same value to ensure the app can accuratly capture the screen area of the window.
* Start/Stop:  
	With this button you can start and stop the relay.
	
### Performance Tips
A main factor to the performance is the native resolution of the GTNXi window. To improve the performance beyond what is possible with the settings provided by the app you can try the following:
* Reduce the window size, if it is bigger than you need.
* Use the windows display settings to increase the scaling of the display you are displaying the GTNXi window on. This will reduce the native resolution of the window at the same apparent size.
* Reduce the resolution of the monitor you are displaying the GTNXi window on. For example I am using it on a high-res tablet using Spacedesk, and choosing 75% of the tablets native resolution in Spacedesk already gives a good boost in performance.

### Aircraft Integration
You can replace any screen/gauge in an aircraft by creating a mod of the panel.cfg.
In the panel.cfg you only have to replace the existing gauge path with either "NavSystems/gtn-screen-relay/gtnscreenrelay750.html" or "NavSystems/gtn-screen-relay/gtnscreenrelay650.html".

For example to integrate the GTN 650Xi screen into the Robin CAP-10 as replacement for the GNS 430 screen simply create a mod and change the line  
`htmlgauge00=NavSystems/GPS/AS430/AS430.html, 0, 0, 350, 190`  
to  
`htmlgauge00=NavSystems/gtn-screen-relay/gtnscreenrelay650.html, 0, 0, 350, 190`  

Also use the other aircraft integrations from this mod as an reference.
