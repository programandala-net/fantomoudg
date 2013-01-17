#! /usr/bin/env gforth

\ tichar2udg.fs
\
\ Convert TI BASIC character definitions
\ (for TI-99 computers) to 8x8 binary patterns
\ (for Sinclair ZX Spectrum and SAM Coupé computers).
\
\ Por/Far/By: Marcos Cruz (programandala.net)
\ 2013-01-17
\

: binary  ( -- )
  2 base !
  ;
: row  ( ud -- )
  \ Print a whole 8-bit number.
  <# # # # # # # # # #> type cr
  ;
: chardef  ( ca u -- )
  \ Print the binary pattern of a TI-99 character definition.
  \ ca u = string with 16 hex digits.
  base @ >r  hex
  bounds do
    0. i 2  hex >number 2drop  binary row
  2 +loop cr
  r> base !
  ;

s" 183C3CFF3C3C3C3C" chardef
s" 472F1F3E7CFA7120" chardef
s" 0808FEFFFFFE0808" chardef
s" 2071FA7C3E1F2F47" chardef
s" 3C3C3C3CFF3C3C18" chardef
s" 048E5F3E7CF8F4E2" chardef
s" 10107FFFFF7F1010" chardef
s" E2F4F87C3E5F8E04" chardef
s" 0000001818000000" chardef
s" 187C7CFFFFFF5E1C" chardef
s" 003C203820202000" chardef
s" 001824202C241800" chardef

bye
