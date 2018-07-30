export default class Animation {
    constructor() {
        this.firstRequestId = null;
        this.secondRequestId = null;
    }

    start = (func) => {
        this.firstRequestId = requestAnimationFrame(() => {
            this.secondRequestId = requestAnimationFrame(func);
        });
    }

    finish = () => {
        cancelAnimationFrame(this.secondRequestId);
        cancelAnimationFrame(this.firstRequestId);
    }
}
