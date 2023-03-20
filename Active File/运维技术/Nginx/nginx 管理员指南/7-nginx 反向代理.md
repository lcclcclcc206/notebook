# NGINX Reverse Proxy

Configure NGINX as a reverse proxy for HTTP and other protocols, with support for modifying request headers and fine-tuned buffering of responses.

This article describes the basic configuration of a proxy server. You will learn how to pass a request from NGINX to proxied servers over different protocols, modify client request headers that are sent to the proxied server, and configure buffering of responses coming from the proxied servers.

## Introduction

Proxying is typically used to distribute the load among several servers, seamlessly show content from different websites, or pass requests for processing to application servers over protocols other than HTTP.

## Passing a Request to a Proxied Server

When NGINX proxies a request, it sends the request to a specified proxied server, fetches the response, and sends it back to the client. It is possible to proxy requests to an HTTP server (another NGINX server or any other server) or a non-HTTP server (which can run an application developed with a specific framework, such as PHP or Python) using a specified protocol. Supported protocols include [FastCGI](https://nginx.org/en/docs/http/ngx_http_fastcgi_module.html), [uwsgi](https://nginx.org/en/docs/http/ngx_http_uwsgi_module.html), [SCGI](https://nginx.org/en/docs/http/ngx_http_scgi_module.html), and [memcached](https://nginx.org/en/docs/http/ngx_http_memcached_module.html).

To pass a request to an HTTP proxied server, the [proxy_pass](https://nginx.org/en/docs/http/ngx_http_proxy_module.html#proxy_pass) directive is specified inside a [location](https://nginx.org/en/docs/http/ngx_http_core_module.html#location). For example:

```nginx
location /some/path/ {
    proxy_pass http://www.example.com/link/;
}
```

This example configuration results in passing all requests processed in this location to the proxied server at the specified address. This address can be specified as a domain name or an IP address. The address may also include a port:

```nginx
location ~ \.php {
    proxy_pass http://127.0.0.1:8000;
}
```

Note that in the first example above, the address of the proxied server is followed by a URI, `/link/`. If the URI is specified along with the address, it replaces the part of the request URI that matches the location parameter. For example, here the request with the `/some/path/page.html` URI will be proxied to `http://www.example.com/link/page.html`. If the address is specified without a URI, or it is not possible to determine the part of URI to be replaced, the full request URI is passed (possibly, modified).

## Passing Request Headers

By default, NGINX redefines two header fields in proxied requests, “Host” and “Connection”, and eliminates the header fields whose values are empty strings. “Host” is set to the `$proxy_host` variable, and “Connection” is set to `close`.

To change these setting, as well as modify other header fields, use the [proxy_set_header](https://nginx.org/en/docs/http/ngx_http_proxy_module.html#proxy_set_header) directive. This directive can be specified in a [location](https://nginx.org/en/docs/http/ngx_http_core_module.html#location) or higher. It can also be specified in a particular [server](https://nginx.org/en/docs/http/ngx_http_core_module.html#server) context or in the [http](https://nginx.org/en/docs/http/ngx_http_core_module.html#http) block. For example:

```nginx
location /some/path/ {
    proxy_set_header Host $host;
    proxy_set_header X-Real-IP $remote_addr;
    proxy_pass http://localhost:8000;
}
```

In this configuration the “Host” field is set to the [$host](https://nginx.org/en/docs/http/ngx_http_core_module.html#variables) variable.

To prevent a header field from being passed to the proxied server, set it to an empty string as follows:

```nginx
location /some/path/ {
    proxy_set_header Accept-Encoding "";
    proxy_pass http://localhost:8000;
}
```