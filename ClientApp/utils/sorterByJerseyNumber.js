export default function sorterByJerseyNumber(a, b) {
    if (a.jerseyNumber > b.jerseyNumber) { return 1; }
    if (a.jerseyNumber < b.jerseyNumber) { return -1; }
    return 0;
}
