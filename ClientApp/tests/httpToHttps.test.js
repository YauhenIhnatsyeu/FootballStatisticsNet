import httpToHttps from "../utils/httpToHttps";

test("casual http to https", () => {
    expect(httpToHttps("http://jestjs.io/docs/en/expect")).toBe("https://jestjs.io/docs/en/expect");
});

test("if url is already https, nothing must happen", () => {
    expect(httpToHttps("https://jestjs.io/docs/en/expect")).toBe("https://jestjs.io/docs/en/expect");
});

test("if url doesn't start with http, nothing must happen", () => {
    expect(httpToHttps("something-http://jestjs.io/docs/en/expect")).toBe("something-http://jestjs.io/docs/en/expect");
    expect(httpToHttps("something-https://jestjs.io/docs/en/expect")).toBe("something-https://jestjs.io/docs/en/expect");
});

test("if url contains multiple http parts, only beginning must be changed", () => {
    expect(httpToHttps("http://jestjs-http-.io/docs/en/expect-http")).toBe("https://jestjs-http-.io/docs/en/expect-http");
    expect(httpToHttps("something-http://jestjs-http-.io/docs/en/expect-http")).toBe("something-http://jestjs-http-.io/docs/en/expect-http");
});
