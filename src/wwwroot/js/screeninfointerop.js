export class ScreenInfoInterop {

    static get() {
        return {
            width: window.innerWidth || document.documentElement.clientWidth || document.body.clientWidth,
            height: window.innerHeight || document.documentElement.clientHeight || document.body.clientHeight,
            devicePixelRatio: window.devicePixelRatio || 1,
            isLandscape: window.innerWidth > window.innerHeight,
            orientation: screen.orientation ? screen.orientation.type : (window.innerWidth > window.innerHeight ? "landscape" : "portrait"),
            isTouchDevice: 'ontouchstart' in window || navigator.maxTouchPoints > 0,
            userAgent: navigator.userAgent
        };
    };
}

window.ScreenInfoInterop = ScreenInfoInterop;