export default function startAnimation(func) {
    requestAnimationFrame(() => {
        requestAnimationFrame(func);
    });
}
