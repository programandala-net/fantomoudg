#! /usr/bin/env gforth

\ udg_x_to_bin.fs

\ This file is part of FantomoUDG
\ http://programandala.net/en.program.fantomoudg.html

\ Last modified 20221106T2020+0100

\ ==============================================================
\ Description

\ This program contains code common to two converters:
\ <udg_code_to_bin.fs> and <udg_tap_to_bin.fs>.

\ ==============================================================
\ Author

\ Marcos Cruz (programandala.net), 2017, 2022.

\ ==============================================================
\ License

\ You may do whatever you want with this work, so long as you
\ retain every copyright, credit and authorship notice, and this
\ license.  There is no warranty.

\ ==============================================================
\ History

\ 2017-01-08: Start.
\
\ 2022-11-06: Code extracted from <udg_tap_to_bin.fs> in order to
\ share it with the new <udg_code_to_bin.fs>.

\ ==============================================================
\ Main

only forth definitions  decimal

8 constant scans/udg

variable scan#  \ counter
variable udg#   \ counter

: binary  ( -- )  2 base !  ;

: .scan  ( c -- )
  base @ >r
  s>d binary <# # # # # # # # # #> type
  r> base !  ;

: char-code  ( c1 -- c2 )  bl +  ;

: udg-code  ( c1 -- c2 )  144 +  ;

: ascii?  ( c -- f )  bl 127 within  ;

: .udg-position  ( c -- )  ." UDG position " .  ;

: .udg-code  ( c -- )  ." UDG " . ." in a UDG set"  ;

: .ascii-description  ( c -- )
  ." character " dup . dup ascii?
  if    ." ('" emit ." ') "
  else  drop
  then  ." in a font"  ;

: .description  ( c -- )
  ." \ " dup .udg-position ." = "
         dup udg-code .udg-code ."  = "
         char-code .ascii-description cr ;

: first-scan?  ( -- f )  scan# @ 0=  ;

: last-scan?  ( -- f )  scan# @ scans/udg =  ;

: next-scan  ( -- )  1 scan# +! cr  ;

: next-udg  ( -- )  1 udg# +! scan# off cr  ;

: init  ( -- )  udg# off  scan# off  ;

: udgs>bin  ( ca len -- )
  init  bounds ?do
    first-scan? if  udg# @ .description  then
    i c@ .scan next-scan
    last-scan? if  next-udg  then
  loop  ;
  \ Convert the UDG definitions contained in the memory zone
  \ _ca len_ (8 bytes per UDG) to binary numbers printed to standard
  \ output, with Forth comments.
