export default function httpToHttps(urlParam) {
    let url = urlParam;
    const regexp = /^http:/;
    if (regexp.test(url)) {
        url = url.replace(regexp, "https:");
    }
    return url;
}
