#ifndef crypto_auth_H
#define crypto_auth_H

#include <stddef.h>

#include "sodium_crypto_auth_hmacsha512256.h"
#include "sodium_export.h"

#ifdef __cplusplus
# ifdef __GNUC__
#  pragma GCC diagnostic ignored "-Wlong-long"
# endif
extern "C" {
#endif

#define crypto_auth_BYTES crypto_auth_hmacsha512256_BYTES
size_t  crypto_auth_bytes(void);

#define crypto_auth_KEYBYTES crypto_auth_hmacsha512256_KEYBYTES
size_t  crypto_auth_keybytes(void);

#define crypto_auth_PRIMITIVE "hmacsha512256"
const char *crypto_auth_primitive(void);

int crypto_auth(unsigned char *out, const unsigned char *in,
                unsigned long long inlen, const unsigned char *k)
            __attribute__ ((nonnull));

int crypto_auth_verify(const unsigned char *h, const unsigned char *in,
                       unsigned long long inlen, const unsigned char *k)
            __attribute__ ((warn_unused_result)) __attribute__ ((nonnull));

void crypto_auth_keygen(unsigned char k[crypto_auth_KEYBYTES])
            __attribute__ ((nonnull));

#ifdef __cplusplus
}
#endif

#endif
