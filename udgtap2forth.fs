#! /usr/bin/env gforth

\ udgtap2forth.fs

\ By Marcos Cruz (programandala.net)

\ ==============================================================
\ Description

\ This Forth program converts a ZX Spectrum TAP file, containing User
\ Defined Graphics, to hex data ready to be used in a Forth program.

\ ==============================================================
\ Usage

\ s" filename.tap" udgtap2forth.fs > filename.fs

\ ==============================================================
\ History

\ 2015-03-23: Start.
\ 2016-03-01: Fixed, improved.

\ ==============================================================
\ Requirements

require galope/unslurp.fs

\ ==============================================================
\ Main

variable scans  \ counter
variable udg    \ counter

: hex8.  ( b -- )  i c@ <# # # #> type space  ;
: last-scan?  ( -- f )  scans @ 8 =  ;
: next-scan  ( -- )  1 scans +!  ;
: next-udg  ( -- )  udg @ hex8. ." udg!" cr  1 udg +!  ;

: udgs>forth  ( ca len -- )
  \ ca len = UDG definitions (8 bytes per graphic)
  scans off  144 udg !  hex
  bounds ?do
    i c@ hex8.  next-scan  last-scan? if  next-udg  then
  loop  decimal  ;

: behead  ( ca1 len1 -- ca2 len2 )  24 /string  ;
  \ Remove the TAP file header from the TAP file image _ca1 len1_.

: udgtap>forth ( ca len -- )  slurp-file behead udgs>forth  ;
  \ ca len = TAP file name
