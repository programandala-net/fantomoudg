#! /usr/bin/env gforth

\ udg-to.fs

\ This file is part of FantomoUDG
\ http://programandala.net

\ Last modified 201612211554

\ ==============================================================
\ Description

\ Converters from ZX Spectrum UDG data to BASIC and Forth source
\ formats.

\ ==============================================================
\ Author

\ Marcos Cruz (programandala.net), 2015, 2016.

\ ==============================================================
\ License

\ You may do whatever you want with this work, so long as you
\ retain every copyright, credit and authorship notice, and this
\ license.  There is no warranty.

\ ==============================================================
\ History

\ 2015-01-07: Original version for BASIC data, called "show_udg.fs".
\
\ 2016-02-15: New version, improved and renamed.
\
\ 2016-12-21: Update file header and source layout.

\ ==============================================================

: udg>data  ( n0..n7 -- )
  ." data "
  -1 7 -do
    i pick .  i if  [char] , emit  then
  1 -loop  cr  ;

[undefined] binary [if]
  : binary 2 base !  ;
[then]

variable binary-prefix?  \ show "%" before binary scans?
binary-prefix? off

: binary-prefix  ( -- )
  binary-prefix? @ if  [char] % hold  then  ;

: binary-scan  ( -- )
  base @ >r  binary
  s>d <#  # # # # # # # # binary-prefix #> type
  r> base !  ;

: udg>bin  ( n0..n7 -- )
  -1 7 -do
    i pick binary-scan cr
  1 -loop  cr  ;

: 2x1udg>bin  ( n0..n7 n8..n15 -- )
  -1 7 -do
    i 8 + pick binary-scan
    i     pick binary-scan cr
  1 -loop  cr  ;
