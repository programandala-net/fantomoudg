#! /usr/bin/env gforth

\ udgti2bin.fs

\ This file is part of FantomoUDG
\ http://programandala.net

\ Last modified 201612211651

\ ==============================================================
\ Description

\ This program converts TI BASIC UDGs (for TI-99 computers) to
\ 8x8 binary grids.

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
\ Usage

\ See <udgti2bin.demo.fs> for a usage example.

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
\ 2016-12-21: Update file header and source layout. Improve
\ documentation and code. Extract the data to its own file, as a
\ demo.

\ ==============================================================

: binary  ( -- )  2 base !  ;

: row  ( ud -- )
  base @ >r  binary <# # # # # # # # # #> type cr  r> base !  ;
  \ Print the UDG row _ud_.

: chardef  ( ca len -- )
  base @ >r hex
  bounds do
    0. i 2  >number 2drop  row
  2 +loop cr
  r> base !  ;
  \ Print the binary pattern of a TI-99 character definition,
  \ defined as 16 hex digits in the string _ca len_.
