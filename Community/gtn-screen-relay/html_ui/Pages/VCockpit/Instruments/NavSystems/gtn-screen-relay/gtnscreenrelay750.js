class GtnScreenRelay750 extends GtnScreenRelay {
    constructor() {
        super("GTN750");
    }
    get templateID() { return "GtnScreenRelay750"; }
}

registerInstrument('gtn-screen-relay-750', GtnScreenRelay750);
SimVar.SetSimVarValue("L:PMS50_GTN750_INSTALLED", "bool", true);
