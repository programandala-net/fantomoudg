#! /usr/bin/env gforth

\ udgti2bin.fs

\ This file is part of FantomoUDG
\ http://programandala.net

\ Last modified 201612211651

\ ==============================================================
\ Description

\ This program converts TI BASIC character definitions (for
\ TI-99 computers) to UDG binary patterns.

\ Input format example:

  \ s" 183C3CFF3C3C3C3C" chardef

\ Output:

  \ 00011000
  \ 00111100
  \ 00111100
  \ 11111111
  \ 00111100
  \ 00111100
  \ 00111100
  \ 00111100

\ ==============================================================
\ Author

\ Marcos Cruz (programandala.net), 2013, 2016.

\ ==============================================================
\ License

\ You may do whatever you want with this work, so long as you
\ retain every copyright, credit and authorship notice, and this
\ license.  There is no warranty.

\ ==============================================================
\ History

\ 2013-01-17: First version.
\
\ 2016-12-21: Update file header and source layout.

\ ==============================================================

: binary  ( -- )  2 base !  ;

: row  ( ud -- )  <# # # # # # # # # #> type cr  ;
  \ Print a whole 8-bit number.

: chardef  ( ca len -- )
  base @ >r
  bounds do
    0. i 2  hex >number 2drop  binary row
  2 +loop cr
  r> base !  ;
  \ Print the binary pattern of a TI-99 character definition,
  \ defined as 16 hex digits in the string _ca len_.

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
