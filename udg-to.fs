#! /usr/bin/env gforth

\ udg-to.fs

\ Converters from ZX Spectrum UDG data to
\ BASIC and Forth source formats.

\ By Marcos Cruz (programandala.net)

\ 2015-01-07: Original version for BASIC data, called "show_udg.fs".
\ 2016-02-15: New version, improved and renamed.

: udg>data  ( n0..n7 -- )
  ." data "
  -1 7 -do
    i pick .
    i if  [char] , emit  then
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
    i pick binary-scan cr
  1 -loop  cr  ;
