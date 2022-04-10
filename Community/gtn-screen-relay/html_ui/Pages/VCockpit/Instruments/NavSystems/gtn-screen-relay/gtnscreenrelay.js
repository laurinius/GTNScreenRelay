function requestSettings(callback) {
    let httpRequest = new XMLHttpRequest();
    httpRequest.timeout = 1000;
    httpRequest.onload = function() {
        try {
            let settings = JSON.parse(this.responseText);
            callback(settings);
        } catch (e) {
        }
    };
    httpRequest.open("GET", "http://localhost:45783/settings");
    httpRequest.send(null);
}

class GtnScreenRelay extends BaseInstrument {
    constructor(_unitType) {
        super();
        this.img = new Image();
        this.imageLoadingInProgress = false;
        this.imageLoadingError = false;
        this.lastSettingsRequest = 0;
        this.settingsRequestInterval = 5000;
        this.lastRequest = 0;
        this.requestInterval = 50;
        this.requestIntervalOnError = 5000;
        this.imageUrl = "http://localhost:45783/" + _unitType + "?random="
    }
    connectedCallback() {
        super.connectedCallback();
        
        var canvas = this.getChildById("gtn-canvas");
        var w = canvas.clientWidth;
        var h = canvas.clientHeight;
        canvas.setAttribute("width", w)
        canvas.setAttribute("height", h)
        var context = canvas.getContext("2d");
        this.img.onload = () => {
            if (h == 0 || w == 0) {
                w = canvas.clientWidth;
                h = canvas.clientHeight;
                if (h == 0 || w == 0) {
                    this.imageLoadingError = true;
                    this.imageLoadingInProgress = false;
                    return;
                } else {
                    canvas.setAttribute("width", w)
                    canvas.setAttribute("height", h)
                }
            }
            context.drawImage(this.img, 0, 0, w, h);
            this.imageLoadingError = false;
            this.imageLoadingInProgress = false;
        };
        this.img.onerror = () => {
            this.imageLoadingError = true;
            this.imageLoadingInProgress = false;
        }
    }
    disconnectedCallback() {
        super.disconnectedCallback();
    }
    onInteractionEvent(_args) {
    }
    Update() {
        super.Update();
        var n = Date.now();
        if (!this.imageLoadingInProgress && (n - this.lastRequest) >= (this.imageLoadingError ? this.requestIntervalOnError : this.requestInterval)) {
            this.imageLoadingInProgress = true;
            this.img.src = this.imageUrl + n;
            this.lastRequest = n;
        }
        if ((n - this.lastSettingsRequest) > this.settingsRequestInterval) {
            this.lastSettingsRequest = n;
            requestSettings(settings => {
                if (settings.refreshInterval != null) {
                    this.requestInterval = settings.refreshInterval;
                }
            });
        }
    }
}
