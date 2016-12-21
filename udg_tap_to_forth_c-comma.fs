#! /usr/bin/env gforth

\ udg_tap_to_forth_c-comma.fs

\ This file is part of FantomoUDG
\ http://programandala.net

\ Last modified 201612212324

\ ==============================================================
\ Description

\ This program converts a ZX Spectrum TAP file, containing User
\ Defined Graphics, to a Forth source that stores the graphics
\ into Forth data space using the `c,` word, one graphic per
\ line.

\ ==============================================================
\ Usage

\ ./udg_tap_to_forth_c-comma.fs input_file.tap > output_file.fs

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

\ 2016-12-21: Start.

\ ==============================================================
\ Main

variable scans  \ counter

8 constant scans/udg

: .scan  ( n -- )
  base @ >r s>d hex <# # # '$' hold #> type space r> base !  ;

: last-scan?  ( -- f )  scans @ scans/udg =  ;

: next-scan  ( -- )  1 scans +!  ;

: new-udg  ( -- )  scans off cr  ;

: udgs>forth  ( ca len -- )
  new-udg  bounds ?do
    i c@ .scan ." c, " next-scan last-scan? if  new-udg  then
  loop  ;
  \ Convert the UDG definitions contained in the memory zone
  \ _ca len_ (8 bytes per UDG) to Forth source printed to
  \ standard output.

: behead  ( ca1 len1 -- ca2 len2 )  24 /string 1-  ;
  \ Remove the TAP file header from the TAP file contents _ca1
  \ len1_, and the checksum byte of the data block, resulting a string
  \ _ca2 len2_ that contains only the actual data of the file.

: udgtap>forth ( ca len -- )  slurp-file behead udgs>forth  ;
  \ Convert the UDGs contained in TAP file _ca len_ to Forth
  \ source printed to standard output.

1 arg udgtap>forth bye
