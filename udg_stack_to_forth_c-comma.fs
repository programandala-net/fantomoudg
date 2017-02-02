#! /usr/bin/env gforth

\ udg_stack_to_forth_c-comma.fs

\ This file is part of FantomoUDG
\ http://programandala.net

\ Last modified 201702020018

\ ==============================================================
\ Description

\ This program provides a word that prints a User Defined Graphics,
\ defined as 8 numbers on the stack, as Forth source that stores those
\ numbers using `c,`, one graphic per line.

\ ==============================================================
\ Usage example

\ -----------------------------------
\ #! /usr/bin/env gforth
\
\ include udg_bin_to_forth_c-comma.fs
\
\ 2 base !
\
\ 00011100
\ 00100010
\ 01011001
\ 10100101
\ 10100001
\ 10011010
\ 01000010
\ 00111100 udg
\
\ bye
\ -----------------------------------

\ ==============================================================
\ Author

\ Marcos Cruz (programandala.net), 2017.

\ ==============================================================
\ License

\ You may do whatever you want with this work, so long as you
\ retain every copyright, credit and authorship notice, and this
\ license.  There is no warranty.

\ ==============================================================
\ History

\ 2017-02-02: Start.

\ ==============================================================

8 constant scans/udg

: .scan  ( n -- )
  base @ >r s>d hex <# # # '$' hold #> type space r> base !  ;

: udg  ( b0..b1 -- )
  0 scans/udg 1- ?do
    i roll .scan ." c, "
  -1 +loop  cr  ;
  \ Convert a UDG definition _b0..b1_
  \ to Forth source printed to standard output.

