class GtnScreenRelay650 extends GtnScreenRelay {
    constructor() {
        super("GTN650");
    }
    get templateID() { return "GtnScreenRelay650"; }
}

registerInstrument('gtn-screen-relay-650', GtnScreenRelay650);
SimVar.SetSimVarValue("L:PMS50_GTN650_INSTALLED", "bool", true);
